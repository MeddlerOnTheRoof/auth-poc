// signing key: secret

// jwt header:
//{
//    "typ": "JWT",
//    "alg": "HS256"
//}

// Claims
// iss - issuer
// sub - subject
// aud - audience
// exp - expiration time
// nbf - not before
// iat - issued at
// jti - jwt id

// jwt payload
//{
//    "iss": "",
//    "sub": "1234567890",
//    "aud": "",
//    "name": "John Doe",
//    "admin": true,
//    "jti": "f4458401-2540-4052-89ac-4990568433fb",
//    "iat": 1496153059,
//    "nbf": 1496153059,
//    "exp": 1496156659
//}

const jwt: string = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiIiLCJzdWIiOiIxMjM0NTY3ODkwIiwiYXVkIjoiIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImp0aSI6ImY0NDU4NDAxLTI1NDAtNDA1Mi04OWFjLTQ5OTA1Njg0MzNmYiIsImlhdCI6MTQ5NjE1MzA1OSwibmJmIjoxNDk2MTUzMDU5LCJleHAiOjE0OTYxNjM1NzV9.DzbGqNikQgGdVNupp6-T8LKUPDcbt7DNU1i6yGDOU8s";

import { Http } from '@angular/http';

export class TokenService {
    // should we keep the token in a different location e.g. a cookie
    private token: string;
    // should the user role be string or should we go ID based
    private userRole: string;

    // map components to module
    // map modules to userRoles
    // this way only this mapping section needs be changed if they want 
    // to change what roles are available and what modules they have access to
    // could even try to have this section moved to a configurable asset that gets
    // read live and can change from env to env in dev op pipeline

    // should this also govern access to services?

    constructor(private http: Http) {

    }

    public login(username: string, password: string): void {
        // fetch token

        // decrypt and parse token for user role
    }

    public isExpired(): boolean {

    }

    // rename to be more concise?
    // should it except an enum val instead? with the enum val being the module's components array's index in the array of modules? or is that too fragile
    public checkModuleAuthorization(module: string): boolean {
        // should check if the user is authroized for a component
        // components can then use this to determine what to render in their html
        // the route resolver can use this to forbid access to certain routes

        

        return true;
    }

    public logout(): void {
        // should send request to api to cause token to expire before its exp claim
    }

    // should we expose http services through a base class with the token and base url available?
}

const ModuleMap = {
    // each property represents a module and is an arrray containing component classes
    //UnitModule: [
    //]

    //UserModule: [
    //    UserDetailComponent,

    //]
}

const RoleAccess = {
    // each property in 
}