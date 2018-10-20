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
    }

    disbaleAllInteractions() {
        for (let interaction of this.Interactions) {
            interaction.setActive(false);
        }
    }

    setInteraction(interaction) {
        if (interaction == Geometry.POINT || interaction == Geometry.LINESTRING || interaction == Geometry.POLYGON) {
            this.disbaleAllInteractions();
            this.map.removeInteraction(this.DrawInteraction);
            this.Interactions.splice(this.Interactions.indexOf(this.DrawInteraction), 1)
            this.DrawInteraction = new ol.interaction.Draw({
                source: this.source,
                type: interaction
            });
            this.Interactions.push(this.DrawInteraction);
            this.map.addInteraction(this.DrawInteraction);
        } else if (interaction == Geometry.HAND) {
            this.disbaleAllInteractions();
            this.SelectInteraction.setActive(true);
        } else if (interaction == Geometry.TRANSLATE) {
            this.disbaleAllInteractions();
            this.TranslateInteraction.setActive(true);
        }
        else if (interaction == Geometry.MODIFY) {
            this.disbaleAllInteractions();
            this.SelectInteraction.setActive(true);
            this.ModifyInteraction.setActive(true);
        }
    }
}