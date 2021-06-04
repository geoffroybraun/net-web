/**
 * Manage date inputs for the application
 */
var DateManager = {
    /**
     * Enable 'DatePicker' design for all 'datepicker' CSS class elements by default
     */
    EnableDefault: function () {
        DateManager.Enable('.datepicker');
    },

    /**
     * Enable 'DatePicker' design for selected elements
     * @param {any} querySelector The query selector to use when enabling 'DtaePicker' design
     */
    Enable: function (querySelector) {
        $.fn.datepicker.dates['fr'] = {
            days: ["Dimanche", "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "SAmedi"],
            daysShort: ["Dim", "Lun", "Mar", "Mer", "Jeu", "Ven", "Sam"],
            daysMin: ["Di", "Lu", "Ma", "Me", "Je", "Ve", "Sa"],
            months: ["Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"],
            monthsShort: ["Jan", "Fév", "Mar", "Avr", "Mai", "Jui", "Jui", "Aoû", "Sep", "Oct", "Nov", "Déc"],
            today: "Aujourd'hui",
            clear: "Annuler",
            format: "dd/mm/yyyy",
            titleFormat: "MM yyyy", /* Leverages same syntax as 'format' */
            weekStart: 0
        };
        $(querySelector).datepicker({
            language: 'fr',
            format: 'yyyy-mm-dd'
        });
    }
};
