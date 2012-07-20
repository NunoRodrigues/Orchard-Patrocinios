var LocationWidget = {
    regions : [
            {
                id: 1,
                width: 9,
                height: 22,
                top: 12,
                left: 0,
                color: '#F7C43C',
                title: 'Left'
            },
            {
                id: 2,
                width: 9,
                height: 22,
                top: 12,
                left: 37,
                color: '#A346EE',
                title: 'Right'
            },
            {
                id: 3,
                width: 46,
                height: 9,
                top: 0,
                left: 0,
                color: '#349ED7',
                title: 'Top'
            },
            {
                id: 4,
                width: 46,
                height: 9,
                top: 37,
                left: 0,
                color: '#51DB5E',
                title: 'Bottom'
            }
            // Other Colors #F73BCC, #EE4F45
    ],
    getNew: function (placeHolder, multipleSelection, clickFunction) {
        // Grafico
        var itemContainer = $('<div class="LocationWidget"></div>');

        // Grafico - Items
        $.each(this.regions, function (index, value) {
            var item = $('<div class="LocationWidgetItem" location-id="' + value.id + '" title="' + value.title + '" style="width:' + value.width + 'px; height:' + value.height + 'px; top: ' + value.top + 'px; left: ' + value.left + 'px; background:' + value.color + ';"><div>');

            if (multipleSelection) {
                item.click(value, function (args) {
                    var data = args.data;

                    var select = placeHolder.find('select');

                    var item = select.find('option[value="' + data.id + '"]');

                    if (item.attr('selected') == 'selected') {
                        // Tem de ser os dois... e nesta ordem!
                        item.attr('selected', false);
                        item.removeAttr('selected');
                    } else {
                        item.attr('selected', true);
                    }

                    // Refresh
                    select.show();

                    // Fire Changed
                    select.change();
                });
            } else {
                item.click(value, function (args) {
                    var data = args.data;
                    var select = placeHolder.find('select');

                    select.val(data.id);

                    // Refresh
                    select.show();

                    // Fire Changed
                    select.change();
                });
            }

            item.click(value, clickFunction);

            itemContainer.append(item);
        });
        placeHolder.append(itemContainer);

        // Combo
        var combo = combo = $('<select id="" class="LocationWidgetSelect"></select>');

        // Combo - Multiselection
        if (multipleSelection) {
            combo.attr('multiple', 'multiple');
        }

        // Combo - Items
        $.each(this.regions, function (index, value) {
            combo.append('<option value="' + value.id + '">' + value.title + '</option>');
        });

        // Combo - Events
        combo.change(function (args) {
            $(this).find('option:selected').each(function (index, value) {
                placeHolder.find('div.LocationWidgetItem[location-id="' + $(value).val() + '"]').fadeTo(200, 1);
            });

            $(this).find('option:not(option:selected)').each(function (index, value) {
                placeHolder.find('div.LocationWidgetItem[location-id="' + $(value).val() + '"]').fadeTo(200, 0.4);
            });
        });

        // Combo
        placeHolder.append(combo);
        combo.change();
    },
    getValues: function (placeHolder) {
        return $(placeHolder).find('select').val();
    },
    setValues: function (placeHolder, values) {
        $.each(this.regions, function (index, value) {
            alert('TODO');
        });
    }
}