$(function() {
    initializeCollapsers();
    function WebmailViewModel() {
        var self = this;
        self.folders = ['Inbox', 'Archive', 'Sent', 'Spam'];
        self.chosenFolderId = ko.observable();
        self.tabClass = function (tab) {
            return self.chosenFolderId() == tab ? 'active-tab' : '';
        };
        self.goToFolder = function (folder) {
             self.chosenFolderId(folder);
        };
    }

    ko.applyBindings(new WebmailViewModel());
});


function useGetAPI() {

    $.get('/api/mailapi', function(data) {
        alert(data);
    });

}
