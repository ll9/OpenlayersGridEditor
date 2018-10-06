﻿class FeatureTranslator {
    constructor(map) {
        this.map = map;
        this.translate = new ol.interaction.Translate();

        this.map.addInteraction(this.translate)
    }
}