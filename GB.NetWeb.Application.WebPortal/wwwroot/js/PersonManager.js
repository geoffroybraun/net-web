/**
 * Manage persons by providing useful methods
 */
var PersonManager = {
    /**
     * List all available persons
     * @param {any} waitingMessage The message to display while the list is loading
     */
    List: function () {
        var container = $("#persons-list");

        $.ajax({
            url: '/Person/List',
            type: 'get',
            beforeSend: function () {
                var spinnerContent = '<div class="spinner-border" role="status"></div>';
                container.html(spinnerContent)
            },
            success: function (data) {
                container.html(data);
            }
        });
    },

    /**
     * Open a modal with the person creation form
     */
    OpenCreateModal: function () {
        var data = FormManager.Serialize('persons-modal-form');
        data['command'] = {};

        ModalManager.OpenFromAjaxCall('/Person/Create', 'post', data, "persons-modal");
    },

    /**
     * Open a modal with the person deletion form
     * @param {any} ID The person ID to delete
     * @param {any} firstname The person firstname to display
     * @param {any} lastname The person lastname to display
     */
    OpenDeleteModal: function (ID, firstname, lastname) {
        var data = FormManager.Serialize('persons-modal-form');
        data['command'] = {
            id: ID,
            firstname: firstname,
            lastname: lastname,
            runCommand: false
        };

        ModalManager.OpenFromAjaxCall('/Person/Delete', 'post', data, "persons-modal");
    },

    /**
     * Open a modal with the person update form
     * @param {any} ID The person ID to update
     * @param {any} firstname The person firstname to update
     * @param {any} lastname The person lastname to update
     * @param {any} birthdate The person birthdate to update
     */
    OpenUpdateModal: function (ID, firstname, lastname, birthdate) {
        var data = FormManager.Serialize('persons-modal-form');
        data['command'] = {
            id: ID,
            firstname: firstname,
            lastname: lastname,
            birthdate: birthdate,
            runCommand: false
        };

        ModalManager.OpenFromAjaxCall('/Person/Update', 'post', data, "persons-modal");
    },
};
