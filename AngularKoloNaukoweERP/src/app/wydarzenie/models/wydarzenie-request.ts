export class WydarzenieRequest {
    idZespolu: number;
    nazwa: string;
    data: Date;
    miejsce: string;

    constructor(idZespolu: number, nazwa: string, data: Date, miejsce: string){
        this.idZespolu = idZespolu;
        this.nazwa = nazwa;
        this.data = data;
        this.miejsce = miejsce;
        console.log('request-wydarzenie')
    }
    
}