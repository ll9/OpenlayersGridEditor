const Geometry = Object.freeze({
    HAND: "Hand",
    POINT: "Point",
    LINESTRING: "LineString",
    POLYGON: "Polygon",
    TRANSLATE: "Translate",
    MODIFY: "Modify"
});

class InteractionManager {

    constructor(map, source) {
        this.map = map;
        this.source = source

        this.SelectInteraction = new ol.interaction.Select();
        this.DrawInteraction = new ol.interaction.Draw({
            source: this.source,
            type: "Polygon"
        });
        this.TranslateInteraction = new ol.interaction.Translate();
        this.ModifyInteraction = new ol.interaction.Modify({
            features: this.SelectInteraction.getFeatures()
        });
        this.Interactions = [
            this.SelectInteraction,
            this.DrawInteraction,
            this.TranslateInteraction,
            this.ModifyInteraction
        ]

        for (let interaction of this.Interactions) {
            this.map.addInteraction(interaction);
        }
        this.setEvents();
    }

    disbaleAllInteractions() {
        for (let interaction of this.Interactions) {
            interaction.setActive(false);
        }
    }

    setDraw(type) {
        this.map.removeInteraction(this.DrawInteraction);
        this.Interactions.splice(this.Interactions.indexOf(this.DrawInteraction), 1)
        this.DrawInteraction = new ol.interaction.Draw({
            source: this.source,
            type: type
        });
        this.Interactions.push(this.DrawInteraction);
        this.map.addInteraction(this.DrawInteraction);

        this.DrawInteraction.on('drawend', (evt) => {
            let feature = evt.feature;
            let wkt = FeatureTransformer.getWkt(feature);
            if (typeof cefCustomObject !== 'undefined') {
                let id = cefCustomObject.addGeometry(wkt);
                feature.setId(id);
            }
        })
    }

    setEvents() {
        this.ModifyInteraction.on('modifyend', (evt) => {
            let feature = evt.features.item(0);
            this.updateGeometry(feature);
        })
        this.TranslateInteraction.on('translateend', (evt) => {
            let feature = evt.features.item(0);
            this.updateGeometry(feature);
        })
        this.TranslateInteraction.on('translatestart', (evt) => {
            let feature = evt.features.item(0);
            this.zoomToCluster(feature);
        })
        this.SelectInteraction.on('select', (evt) => {
            if (evt.selected.length == 0) return;

            let feature = evt.selected[0];
            this.zoomToCluster(feature);
        })
    }

    /**
     * Updates Geometry of Feature | Cluster
     * @param {Feature | Cluster} feature 
     */
    updateGeometry(feature) {
        if (feature.get('features')) {
            let geometry = feature.getGeometry();
            feature = feature.get('features')[0]
            feature.setGeometry(geometry);
        }
        let wkt = FeatureTransformer.getWkt(feature);
        cefCustomObject.updateGeometry(feature.getId(), wkt);
    }

    /**
     * If feature is a cluster, zoom to extent of cluster
     * @param {ol/geom/Feature} feature 
     */
    zoomToCluster(feature) {
        if (feature.get("features") && feature.get("features").length > 1) {
            let extent = ol.extent.createEmpty();
            for (let clusterFeature of feature.get('features')) {
                ol.extent.extend(extent, clusterFeature.getGeometry().getExtent())
            }
            this.map.getView().fit(extent, {
                duration: 1000
            })
        }
    }


    setInteraction(interaction) {
        if (interaction == Geometry.POINT || interaction == Geometry.LINESTRING || interaction == Geometry.POLYGON) {
            this.disbaleAllInteractions();
            this.setDraw(interaction);
        } else if (interaction == Geometry.HAND) {
            this.disbaleAllInteractions();
            this.SelectInteraction.setActive(true);
        } else if (interaction == Geometry.TRANSLATE) {
            this.disbaleAllInteractions();
            this.TranslateInteraction.setActive(true);
        } else if (interaction == Geometry.MODIFY) {
            this.disbaleAllInteractions();
            this.SelectInteraction.setActive(true);
            this.ModifyInteraction.setActive(true);
        }
    }
}