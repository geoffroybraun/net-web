/**
 * Manage all tooltip toggle for the application
 */
var TooltipManager = {
    /**
     * Enable tooltip toggle for all 'data-toggle' attributes with 'tooltip' value by default
     */
    EnableDefault: function () {
        TooltipManager.Enable('[data-toggle=tooltip]');
    },

    /**
     * Enable tooltip toggle for selected elements
     * @param {any} querySelector The query selector to use when enabling tooltip toggle
     */
    Enable: function (querySelector) {
        $(querySelector).tooltip();
    }
}