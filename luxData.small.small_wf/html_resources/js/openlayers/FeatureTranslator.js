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
            let feature = event.features.item(0);
            let id = feature.getId();
            let lonlat = ol.proj.transform(event.coordinate, 'EPSG:3857', 'EPSG:4326');

            console.log(id);
            console.log(lonlat);
        })
    }
}