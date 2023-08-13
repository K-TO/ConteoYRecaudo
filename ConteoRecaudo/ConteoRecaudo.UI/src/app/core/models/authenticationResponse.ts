export class AuthenticationResponse {
    id: string;
    firstName: string;
    lastName: string;
    userName: string;
    email: string;
    token: string;
    errorMessage: string;

    constructor(id: string, firstName: string, lastName: string, userName: string, email: string, token: string, errorMessage: string) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.userName = userName;
        this.email = email;
        this.token = token;
        this.errorMessage = errorMessage;
    }
}