const map = new ol.Map({
    target: 'map',
    layers: [
        new ol.layer.Tile({
            source: new ol.source.OSM()
        })
    ],
    view: new ol.View({
        center: ol.proj.fromLonLat([37.41, 8.82]),
        zoom: 4
    })
});

const layerManager = new LayerManager(map);
const interactionManager = new InteractionManager(map, layerManager.source);
interactionManager.setInteraction(Geometry.HAND);


var dims = {
    a0: [1189, 841],
    a1: [841, 594],
    a2: [594, 420],
    a3: [420, 297],
    a4: [297, 210],
    a5: [210, 148]
};

document.addEventListener("DOMContentLoaded",function(){
    var exportButton = document.getElementById('export-pdf');
    //here code

    exportButton.addEventListener('click', function () {
        exportButton.disabled = true;
        document.body.style.cursor = 'progress';
    
        var format = 'a4'
        var resolution = 72
        var dim = dims[format];
        var width = Math.round(dim[0] * resolution / 25.4);
        var height = Math.round(dim[1] * resolution / 25.4);
        var size = /** @type {module:ol/size~Size} */ (map.getSize());
        var extent = map.getView().calculateExtent(size);
    
        map.once('rendercomplete', function (event) {
            var canvas = event.context.canvas;
            var data = canvas.toDataURL('image/jpeg');
            var pdf = new jsPDF('landscape', undefined, 'a4');
            pdf.addImage(data, 'JPEG', 0, 0, dim[0], dim[1]);
            pdf.save('map.pdf');
            // Reset original map size
            map.setSize(size);
            map.getView().fit(extent, {
                size: size
            });
            exportButton.disabled = false;
            document.body.style.cursor = 'auto';
        });
    
        // Set print size
        var printSize = [width, height];
        map.setSize(printSize);
        map.getView().fit(extent, {
            size: printSize
        });
    
    }, false);
});