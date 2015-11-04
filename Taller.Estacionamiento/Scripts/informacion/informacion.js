
//$(document).ready(function  () {
// load_time_picker("form-field-mask-4");
// load_time_picker("form-field-mask-5");
//	load_map();
//});

function load_time_picker(timePicker) {
    var mytime = $('#' + timePicker)[0];
    if (mytime.type !== 'time') {//if browser doesn't support "time" input
        $(mytime).timepicker({
            minuteStep: 1,
            showMeridian: false,
            defaultTime: false,
        });
    }
}

function load_map(lat, long) {

    var view = new ol.View({
        center: [lat, long],
        zoom: 14
    });

    var map = new ol.Map({
        layers: [
			new ol.layer.Tile({
			    source: new ol.source.OSM()
			})
        ],
        controls: ol.control.defaults({
            attributionOptions: ({
                collapsible: false,
            })
        }),
        target: 'map',
        view: view
    });

    // var geolocation = new ol.Geolocation({
    // 	tracking: true,
    //   projection: view.getProjection()
    // });

    // var accuracyFeature = new ol.Feature();
    // geolocation.on('change:accuracyGeometry', function() {
    //   accuracyFeature.setGeometry(geolocation.getAccuracyGeometry());
    // });

    // var positionFeature = new ol.Feature();
    // positionFeature.setStyle(new ol.style.Style({
    //   image: new ol.style.Circle({
    //     radius: 6,
    //     fill: new ol.style.Fill({
    //       color: '#3399CC'
    //     }),
    //     stroke: new ol.style.Stroke({
    //       color: '#fff',
    //       width: 2
    //     })
    //   })
    // }));

    // geolocation.on('change:position', function() {
    // 	if (geolocation.getTracking()) {
    // 		var coordinates = geolocation.getPosition();
    // 		positionFeature.setGeometry(coordinates ?
    // 		  new ol.geom.Point(coordinates) : null);
    // 		view.setCenter(coordinates ?
    // 		  coordinates : null);
    // 		geolocation.setTracking(false);

    // 		$("#form-field-6").val(geolocation.getPosition());
    // 	};
    // });

    var iconFeature = new ol.Feature({
        geometry: new ol.geom.Point([lat, long])
    });

    var iconStyle = new ol.style.Style({
        image: new ol.style.Icon(/** @type {olx.style.IconOptions} */({
            anchor: [0.5, 24],
            anchorXUnits: 'fraction',
            anchorYUnits: 'pixels',
            opacity: 1,
            src: '../../Content/img/map-pin.png'
        }))
    });

    iconFeature.setStyle(iconStyle);

    var featuresOverlay = new ol.layer.Vector({
        map: map,
        source: new ol.source.Vector({
            // features: [accuracyFeature, positionFeature, iconFeature],
            features: [iconFeature],
        })
    });

    // map.on('singleclick', function  (evt) {
    // 	console.log(evt.coordinate);
    // 	$("#form-field-6").val(evt.coordinate);
    // 	iconFeature.setGeometry(new ol.geom.Point(evt.coordinate));
    // })

    // map.on('click', function(evt) {
    //   var feature = map.forEachFeatureAtPixel(evt.pixel,
    //       function(feature, layer) {
    //         return feature;
    //       });
    //   if (feature) {
    //     alert("info del estacionamiento");
    //   }
    // });
}

