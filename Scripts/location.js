var LocationWidget = {
    regions : [
            {
                id: 1,
                width: 9,
                height: 22,
                top: 12,
                left: 0,
                color: '#F7C43C !important',
                title: 'Left'
            },
            {
                id: 2,
                width: 9,
                height: 22,
                top: 12,
                left: 37,
                color: '#A346EE !important',
                title: 'Right'
            },
            {
                id: 3,
                width: 46,
                height: 9,
                top: 0,
                left: 0,
                color: '#349ED7 !important',
                title: 'Top'
            },
            {
                id: 4,
                width: 46,
                height: 9,
                top: 37,
                left: 0,
                color: '#51DB5E !important',
                title: 'Bottom'
            }
            // Other Colors #F73BCC, #EE4F45
    ],
    getNew: function (placeHolder, multipleSelection, selectionChangedFunction) {
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

                    // Select - Refresh
                    select.show();

                    // Select - Fire Changed
                    select.change();
                });
            } else {
                item.click(value, function (args) {
                    var data = args.data;
                    var select = placeHolder.find('select');

                    select.val(data.id);

                    // Select - Refresh
                    select.show();

                    // Select - Fire Changed
                    select.change();
                });
            }

            itemContainer.append(item);
        });
        placeHolder.append(itemContainer);

        // Combo
        var combo = combo = $('<select class="LocationWidgetSelect"></select>');

        // Combo - Multiselection
        if (multipleSelection) {
            combo.attr('multiple', 'multiple');
        }

        // Combo - Items
        $.each(LocationWidget.regions, function (index, value) {
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

            // External Events
            if ($.isFunction(selectionChangedFunction)) selectionChangedFunction(this, multipleSelection);
        });

        // Combo
        placeHolder.append(combo);
        combo.change();
    },
    getRegion: function (idTipo) {
        var result = null;
        idTipo = parseInt(idTipo, 10);

        $.each(LocationWidget.regions, function (index, value) {
            if(value.id == idTipo) {
                result = value;
                return false; //neste caso, equivalente a um "break"
            }
        });

        return result;
    },
    setValue: function (source, idTipo) {
        var select = $(source).find('select');
        debugger;
    }
}