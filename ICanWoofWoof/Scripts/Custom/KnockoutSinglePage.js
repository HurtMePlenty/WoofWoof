$(function() {
    initializeCollapsers();
    function WebmailViewModel() {
        var self = this;
        self.folders = ['Inbox', 'Archive', 'Sent', 'Spam'];
        self.chosenFolderId = ko.observable();
        self.folderData = ko.observable();
        self.tabClass = function (tab) {
            return self.chosenFolderId() == tab ? 'active-tab' : '';
        };
        self.goToFolder = function (folder) {
            self.chosenFolderId(folder);
            $.get('/api/mailapi/' + folder, self.folderData);
        };
    }

    ko.applyBindings(new WebmailViewModel());
});

