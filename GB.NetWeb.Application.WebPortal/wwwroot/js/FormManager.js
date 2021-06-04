/**
 * Manage forms by providing useful methods
 */
var FormManager = {
    /**
     * Serialize all inputs form the provided form using its name
     * @param {any} formName The form name to use when serializing its inputs
     * @returns All serialized form inputs
     */
    Serialize: function (formName) {
        var form = $('form[name=' + formName + ']');
        var result = {};

        form.find(':input').each(function (index, element) {
            if (result[$(element).attr('Name')] == null) {
                if ($(element).attr('Type') == 'checkbox') {
                    result[$(element).attr('Name')] = $(element).is(':checked');
                }
                else {
                    result[$(element).attr('Name')] = $(element).val();
                }
            }
        });

        return result;
    },
};
