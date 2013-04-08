$(function() {
    initializeCollapsers();
    function WebmailViewModel() {
        var self = this;
        self.folders = ['Inbox', 'Archive', 'Sent', 'Spam'];
        self.chosenFolderId = ko.observable();
        self.folderData = ko.observable();
        self.chosenMailData = ko.observable(null);
        self.tabClass = function (tab) {
            return self.chosenFolderId() == tab ? 'active-tab' : '';
        };
        self.goToFolder = function (folder) {
            self.chosenFolderId(folder);
            self.chosenMailData(null);
            $.get('/api/mailapi/' + folder, self.folderData);
        };

        self.selectMail = function(mail) {
            self.chosenMailData(mail);
            self.chosenFolderId(null);
        };
    }

    ko.applyBindings(new WebmailViewModel());
});

