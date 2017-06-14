(function () {
    angular.module(APPNAME)
        .config(['momentPickerProvider', function (momentPickerProvider) {
            momentPickerProvider.options({
                /* Picker properties */
                locale: 'en',
                format: 'L LT',
                minView: 'decade',
                maxView: 'hour',
                startView: 'year',
                autoclose: true,
                today: false,
                keyboard: false,

                /* Extra: Views properties */
                leftArrow: '&larr;',
                rightArrow: '&rarr;',
                yearsFormat: 'YYYY',
                monthsFormat: 'MMM',
                daysFormat: 'D',
                hoursFormat: 'ha',
                minutesFormat: moment.localeData().longDateFormat('LT').replace(/[aA]/, ''),
                secondsFormat: '',
                minutesStep: 5,
                secondsStep: 1
            });
        }]);
})();