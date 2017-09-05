var myMap;
var addressFromList = document.getElementById("fromCityList");
var addressToList = document.getElementById("toCityList");
var addressFrom = document.getElementById("fromCity");
var addressTo = document.getElementById("toCity");
var distance = document.getElementById("distanceControl");
var errorString = document.getElementById("error_string");
var sendRequestBtn = document.getElementById("sendRequestButton");
var addressFromRes;
var addressToRes;
var valid = false;
var mapBlock = document.getElementById("map");
var adressesList = document.getElementById("poiAddressList");

function addressFromInput() {

	if (addressFrom.value.length > 0) { addressFromList.disabled = true; } else { addressFromList.disabled = false; };
	sendRequestBtn.disabled = true;
}

function addressToInput() {
	if (addressTo.value.length > 0) { addressToList.disabled = true; } else { addressToList.disabled = false; };
	sendRequestBtn.disabled = true;
}

function lostFocus() {
	setPoints();
}

function init() { }

function showError(errorText) {

	error_string.hidden = false;
	errorString.innerText = errorText;
}

function cleanError() {

	error_string.hidden = true;
	errorString.innerText = '';
}

function setPoints() {

	cleanError();

	valid = true;

	if ((addressFromList.selectedIndex == 0 && addressFrom.value == 0) || (addressTo.value == "" && addressToList.selectedIndex == "")) {
		valid = false;
	}

	if (valid == true) {

		if (addressFrom.value != "") {
			addressFromRes = addressFrom.value;
		} else {
			addressFromRes = adressesList.options[addressFromList.selectedIndex - 1].label;
		}

		if (addressTo.value != "") {
			addressToRes = addressTo.value;
		} else {
			addressToRes = adressesList.options[addressToList.selectedIndex - 1].label;
		}

		if (addressToRes != addressFromRes) {
			if (!myMap) {
				myMap = new ymaps.Map('map', {
					center: [55, 34],
					zoom: 10
				}, {
					searchControlProvider: 'yandex#search'
				});
			}

			distance.value = 0;
			routeCreate();
			mapBlock.hidden = false;
		} else {
			if (myMap) myMap.geoObjects.removeAll();
			showError('Адрес отправления и прибытия совпадают');
			mapBlock.hidden = true;
		}
	}
};

function routeCreate() {
	/**
	 * Создаем мультимаршрут.
	 * Первым аргументом передаем модель либо объект описания модели.
	 * Вторым аргументом передаем опции отображения мультимаршрута.
   */

	// создаем маршрут
	var multiRoute = new ymaps.multiRouter.MultiRoute({
		referencePoints: [
			addressFromRes, // откуда
		   addressToRes    // куда
		],
		params: {
			//Маскимальное количество маршрутов
			results: 1
		}
	}, {
		// Автоматически устанавливать границы карты так, чтобы маршрут был виден целиком.
		boundsAutoApply: true
	});

	//добавляем обработчик ответа с сервера
	multiRoute.model.events.add("requestsuccess", function (event) {
		distance.value = (multiRoute.getRoutes().get(0).properties.get("distance").value / 1000).toFixed();
		sendRequestBtn.disabled = false;
	});


	myMap.geoObjects.removeAll();

	// Добавляем мультимаршрут на карту.
	myMap.geoObjects.add(multiRoute);
}

addressFrom.addEventListener("input", addressFromInput);
addressTo.addEventListener("input", addressToInput);
addressToList.onblur = lostFocus;
addressFromList.onblur = lostFocus;
addressFrom.onblur = lostFocus;
addressTo.onblur = lostFocus;
ymaps.ready(init);