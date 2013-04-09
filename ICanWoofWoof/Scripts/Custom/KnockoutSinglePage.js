$(function() {
    initializeCollapsers();
    function WebmailViewModel() {
        var self = this;
        self.folders = ['Inbox', 'Archive', 'Sent', 'Spam'];
        self.chosenFolderId = ko.observable();
        self.folderData = ko.observable(null);
        self.chosenMailData = ko.observable(null);
        self.tabClass = function (tab) {
            return self.chosenFolderId() == tab ? 'active-tab' : '';
        };
        self.goToFolder = function (folder) {
            location.hash = folder;
        };

        self.selectMail = function(mail) {
            self.chosenMailData(mail);
            self.chosenFolderId(null);
        };

        Sammy(function() {
            this.get('#:folder', function() {
                self.chosenFolderId(this.params.folder);
                self.chosenMailData(null);
                $.get('/api/mailapi/' + this.params.folder, self.folderData);
            });

            this.get('#:folder/', function() {

            });

            this.get('', function() {
                this.app.runRoute('get', '#Inbox');
            });
        }).run();
    }

    ko.applyBindings(new WebmailViewModel());
});

