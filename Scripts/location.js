var LocationWidget = {
    regions: [],
    getNew: function (placeHolder, multipleSelection, selectionChangedFunction) {
        // Grafico
        var itemContainer = $('<div class="LocationWidget"></div>');

        // Grafico - Items
        $.each(LocationWidget.regions, function (index, value) {
            var item = $('<div class="LocationWidgetItem" location-id="' + value.Id + '" title="' + value.Tipo + '" style="width:' + value.Width + 'px; height:' + value.Height + 'px; top: ' + value.PosTop + 'px; left: ' + value.PosLeft + 'px; background:' + value.Color + ';"><div>');

            if (multipleSelection) {
                item.click(value, function (args) {
                    var data = args.data;

                    var select = placeHolder.find('select');

                    var item = select.find('option[value="' + data.Id + '"]');

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

                    select.val(data.Id);

                    // Select - Refresh
                    select.show();

                    // Select - Fire Changed
                    select.change();
                });
            }

            itemContainer.append(item);
        });

        // Combo
        var combo = combo = $('<select class="LocationWidgetSelect"></select>');

        // Combo - Multiselection
        if (multipleSelection) {
            combo.attr('multiple', 'multiple');
        }

        // Combo - Items
        $.each(LocationWidget.regions, function (index, value) {
            combo.append('<option value="' + value.Id + '">' + value.Tipo + '</option>');
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
        var container2 = $('<div></div>');
        container2.append(combo);
        placeHolder.append(container2);

        // Graphic
        placeHolder.append(itemContainer);
        combo.change();
    },
    getRegion: function (idTipo) {
        var result = null;
        idTipo = parseInt(idTipo, 10);

        $.each(LocationWidget.regions, function (index, value) {
            if(value.Id == idTipo) {
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