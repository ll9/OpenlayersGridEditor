class FeatureTranslator {
    constructor(map) {
        this.map = map;
        this.translate = new ol.interaction.Translate();

        this.map.addInteraction(this.translate)
        this.initEvents();
    }

    initEvents() {
        this.translate.on('translateend', (event) => {
            let feature = event.features.item(0);
            let id = feature.getId();
            let format = new ol.format.WKT()

            let wkt = format.writeFeature(feature, {
                dataProjection: 'EPSG:4326',
                featureProjection: 'EPSG:3857'
              })

            cefCustomObject.updateGeometry(id, wkt);
        })
    }
}