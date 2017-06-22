(function () {
    "use strict";
    angular.module(APPNAME)
    .controller('stoogeController', StoogeController);

    function StoogeController() {
        // Administrative stuff
        var vm = this;

        // ViewModel
        vm.items = [
            { id: 3, name: "Larry" },
            { id: 17, name: "Curly" },
            { id: 12, name: "Moe" }
        ];
        vm.item = null;  // copy of item being edited
        vm.itemIndex = -1; // index of item being edited
        vm.select = _select;
        vm.save = _save;
        vm.cancel = _cancel;
        vm.add = _add;
        vm.delete = _delete;

        // "The fold"

        function _select(foo) {
            // Keep track of the position in vm.items of
            // the item we will be editing
            vm.itemIndex = vm.items.indexOf(foo);
            // create a copy of the item for editing
            vm.item = Object.assign({}, foo);
        }

        function _save() {
            if (typeof vm.itemIndex === 'number' && vm.itemIndex >= 0) {
                // for update, replace with new version
                vm.items[vm.itemIndex] = vm.item;
            }
            else {
                // for insert, just push to vm.items
                vm.items.push(vm.item);
            }
            _endEdit();
        }

        function _cancel() {
            _endEdit();
        }

        // create a new empty item
        function _add() {
            // Changing item from null to empty object indicates any
            // ui components for editing should be shown
            vm.item = {};
            vm.itemIndex = -1;
        }

        function _endEdit() { //hides form
            vm.item = null;
            vm.itemIndex = -1;
        }

        function _delete() {
            if (typeof vm.itemIndex === 'number' && vm.itemIndex >= 0) {
                // for delete, remove item from array
                vm.items.splice(vm.itemIndex, 1);
                _endEdit();
            }
        }
    }

})();