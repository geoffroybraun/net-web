/**
 * Manage tables for the application
 */
var TableManager = {
    /**
     * Enable 'DataTable' design for all 'table' elements by default
     */
    EnableDefault: function () {
        TableManager.Enable('table');
    },

    /**
     * Enable 'DataTable' design for selected elements
     * @param {any} querySelector The query selector to use when enabling 'DataTable' design
     */
    Enable: function (querySelector) {
        $(querySelector).DataTable({
            language: {
                url: '//cdn.datatables.net/plug-ins/1.10.24/i18n/French.json'
            }
        });
    },

    /**
     * Retrieve data of a specific row within a selected element from a start index to end one
     * @param {any} element The element where to get the row data
     * @param {any} startIndex The data start index to retrieve
     * @param {any} elementsCount The number of elements to retrieve
     */
    GetRowDataDefault: function (element, startIndex, elementsCount) {
        return TableManager.GetRowData('table', element, startIndex, elementsCount);
    },

    /**
     * Retrieve data of a specific row within a selected element from a start index to end one
     * @param {any} querySelector The query selector to use when selecting the table where to get the data
     * @param {any} element The element where to get the row data
     * @param {any} startIndex The data start index to retrieve
     * @param {any} elementsCount The number of elements to retrieve
     */
    GetRowData: function (querySelector, element, startIndex, elementsCount) {
        var data = $(querySelector).DataTable().row(element).data();
        var slicedData = data.slice(startIndex, elementsCount);

        return slicedData;
    }
}