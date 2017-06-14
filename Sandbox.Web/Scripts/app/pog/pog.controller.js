
(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('pogController', PogController);

    PogController.$inject = ['$scope', 'pogService'];

    function PogController(
        $scope
        , pogService
        ) {

        var vm = this;
        vm.pogService = pogService;
        vm.$scope = $scope;

        // View Model - Properties
        vm.currentPage = 1;
        vm.itemsPerPage = "6";
        vm.maxPaginationButtons = 5;
        vm.totalItems = 1;

        vm.searchText = '';

        vm.items = null;
        vm.onSearchClick = _onSearchClick;
        vm.pageChanged = _pageChanged;

        vm.selectedItem = null;
        vm.editForm = null; // property name must agree with name attribute of form element

        vm.datePattern = '/(0[1-9]|1[012])[- \/.](0[1-9]|[12][0-9]|3[01])[- \/.](19|20)\d\d/';
        vm.dateFormat = 'MM/dd/yyyy';
        vm.datePickerOptions = {
            showWeeks: false,
            dateDisabled: vm.disableWeekends,
            formatDayTitle: 'MMMM yyyy',
            formatMonth: 'MMMM',
            startingDay: 0
        };

        vm.whenInstantPopupOpened = false;
        vm.openWhenInstantPopup = _whenInstantPopupOpen;

        // View Model - Public Methods
        vm.add = _add;
        vm.edit = _edit;
        vm.saveChanges = _saveChanges;
        vm.cancelChanges = _cancelChanges;
        vm.disableWeekends = _disableWeekends;

        render();

        function render() {
            _onSearchClick();
        }

        function _onSearchClick() {
            vm.currentPage = 1;
            _search();
        }

        function _search() {
            vm.pogService.search(vm.searchText, vm.fromInstant, vm.toInstant,
                vm.currentPage, vm.itemsPerPage,
                _onGetAllSuccess, _onGetAllError);
        }

        function _pageChanged() {
            _search();
        }

        function _onGetAllSuccess(data) {
            //this receives the data and calls the special
            //notify method that will trigger ng to refresh UI
            vm.$scope.$apply(function () {
                vm.items = data.items;
                vm.totalItems = data.totalItems;
            });
        }

        function _onGetAllError(jqXhr, error) {
            console.error(jqXHR.responseText);
        }

        function _add() {
            // creating empty object shows the form,
            // ready for editing
            vm.selectedItem = {};
            vm.showEditFormErrors = false;
        }

        function _edit(item) {
            vm.showEditFormErrors = true;
            // To edit, re-fetch the item from the database.
            // This makes sure it is up to date, and allows for cases where the
            // GetAll might return lightweight base objects, but GetByIt might
            // selet a more detailed domain object.
            vm.pogService.getById(item.id, _onGetByIdSuccess, _onGetByIdError);

        }

        function _onGetByIdSuccess(data) {
            vm.$scope.$apply(function () {
                vm.selectedItem = data.item;
                // Use momentjs to deserialize JSON datetimes - if datetime ends with 'Z', moment
                // will interpret as UTC time and convert to local time for display. If datetime omits
                // the Z suffix, moment will interpret it as a local time.
                vm.selectedItem.whenInstantMoment = moment(vm.selectedItem.whenInstant);
                vm.selectedItem.whenLocalDateTimeMoment = moment(vm.selectedItem.whenLocalDateTime);

                vm.selectedItem.whenDateTimeOffsetJs = moment(vm.selectedItem.whenDateTimeOffset).toDate();
            });
        }

        function _onGetByIdError(jqXHR) {
            console.log("Get By Id Failed: " + jqXHR.responseText)
            // $alertService.success("Get By Id Failed: " + jqXHR.responseText);
        }

        function _saveChanges(item) {
            vm.showEditFormErrors = true;

            // Use momentjs to serialize JSON datetimes. If we use toISOString, the UTC datetime will be
            // serialized. If we want Local time, need to explicitly format as YYYY-MM-DDTHH:mm:SS.
            vm.selectedItem.whenInstant = vm.selectedItem.whenInstantMoment.toISOString();
            vm.selectedItem.whenLocalDateTime = vm.selectedItem.whenLocalDateTimeMoment.format('YYYY-MM-DDTHH:mm:SS')

            if (vm.editForm.$valid) {
                if (vm.selectedItem.id) {
                    vm.pogService.put(vm.selectedItem.id, vm.selectedItem, _onPutSuccess, _onPutError);
                }
                else {
                    vm.pogService.post(vm.selectedItem, _onPostSuccess, _onPostError);
                }
            }
        }

        function _onPostSuccess(data) {
            console.log("Inserted");
            //vm.$alertService.success("Inserted");
        }

        function _onPostError(jqXHR) {
            console.log("Post Failed: " + jqXHR.responseText);
            //vm.$alertService.error("Post Failed: " + jqXHR.responseText);
        }

        function _onPutSuccess(data) {
            console.log("Saved");
            //vm.$alertService.success("Saved");
        }

        function _onPutError(jqXHR) {
            console.logo("Save Failed: " + jqXHR.responseText);
            // vm.$alertService.error("Save Failed: " + jqXHR.responseText);
        }

        function _cancelChanges(item) {
            vm.selectedItem = null;
        }

        // Disable weekend selection - doesn't work
        function _disableWeekends(data, mode) {
            var date = data.date,
            mode = data.mode;
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
        }

        function _whenInstantPopupOpen() {
            vm.whenInstantPopupOpened = true;
        }

    }
})();