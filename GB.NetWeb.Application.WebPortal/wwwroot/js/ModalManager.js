/**
 * Manage modals by providing useful methods
 */
var ModalManager = {
    /**
     * Open a modal after having called an URL using ajax and filling the modal with the response content
     * @param {any} url The URL to call using ajax
     * @param {any} method The method to use when calling the URL
     * @param {any} data The data to send through the call
     * @param {any} modalId The modal ID to fill with the response content
     */
    OpenFromAjaxCall: function (url, method, data, modalId) {
        $.ajax({
            url: url,
            type: method,
            data: data,
            success: function (data) {
                var modal = $('#' + modalId);
                modal.html(data);
                $(modal).modal('show');
            }
        });
    },

    /**
     * Submit a form within a modal
     * @param {any} modalId The modal ID where to find the form to submit
     */
    SubmitForm: function (modalId) {
        var modal = $('#' + modalId);
        var form = modal.find('form');
        var data = FormManager.Serialize(form.attr('name'));

        $.ajax({
            url: form.attr('action'),
            type: form.attr('method'),
            data: data,
            success: function (data) {
                modal.html(data);
                $(modal).modal('show');
            }
        });
    }
};
