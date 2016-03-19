var RegisterInputBindingModel = (function () {
    function RegisterInputBindingModel(username, password, email, fullName) {
        this.username = username;
        this.password = password;
        this.email = email;
        this.fullName = fullName;
    }

    return RegisterInputBindingModel;
})();