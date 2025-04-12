window.googleAuth = {
    initialize: (clientId, dotNetHelper) => {
        google.accounts.id.initialize({
            client_id: clientId,
            callback: (response) => {
                dotNetHelper.invokeMethodAsync('OnGoogleLogin', response.credential);
            }
        });

        google.accounts.id.renderButton(
            document.getElementById("g_id_signin"),
            { theme: "outline", size: "large" }
        );
        google.accounts.id.prompt();
    }
};
