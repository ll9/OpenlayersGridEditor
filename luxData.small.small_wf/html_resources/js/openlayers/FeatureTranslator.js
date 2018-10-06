class FeatureTranslator {
    constructor(map) {
        this.map = map;
        this.translate = new ol.interaction.Translate();

        this.map.addInteraction(this.translate)
        this.initEvents();
    }

    initEvents() {
        this.translate.on('translateend', (event) => {
            console.log(event)
        })
    }
}