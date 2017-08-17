function Start() {
    var availableList = 'AvailableList';
    var selectedList = 'SelectedList';

    $('.List').on('click', 'option', function() {
        var optionName = $(this).parent().attr('id');
        var buttonName = '#' + ((optionName == 'AvailableList') ? 'right' : 'left');
        ChangeButtonState(buttonName);
    });

    $('.Buttons').on('click', function(e) {
        var buttonName = e.target.id;
        var oldList = (buttonName == 'right' || buttonName == 'rightAll') ? availableList : selectedList;
        var newList = (buttonName == 'right' || buttonName == 'rightAll') ? selectedList : availableList;
        var optionsCount = (buttonName == 'rightAll' || buttonName == 'leftAll') ? '' : ':selected';
        var selectedOpts = $('#' + oldList + ' option' + optionsCount);
        if (selectedOpts.length == 0) {
            alert("Nothing to move.");
            return;
        }

        $('#' + newList).append($(selectedOpts).clone());
        $(selectedOpts).remove();
        if (buttonName.indexOf('All') !== -1) {
            $('#' + buttonName.replace('All', '')).prop("disabled", true);
            return;
        }
		
        ChangeButtonState('#' + buttonName.replace('All', ''));
    });

    function ChangeButtonState(buttonName) {
        if ($(buttonName).is(':disabled')) {
            $(buttonName).prop("disabled", false);
            return;
        }

        $(buttonName).prop("disabled", true);

    }
};

Start();