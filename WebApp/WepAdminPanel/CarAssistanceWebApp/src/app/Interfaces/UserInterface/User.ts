import {Token} from '@angular/compiler';

export interface UserData
{
    name: string;
    phone: string;
    mail: string;
    id: number;
}

export interface UserLogin{
    login: string;
    password: string;
    token: Token;
}
