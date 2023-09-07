export class ZespolRequest {
    idProjektu!: number;
    idWydarzenia!: number;
    idSprzetu!: number;
    idCzlonka!: number;
    nazwa: string;

    constructor(idProjektu: number, idWydarzenia: number, idSprzetu: number, idCzlonka: number, nazwa: string){
        this.idProjektu = idProjektu;
        this.idWydarzenia = idWydarzenia;
        this.idSprzetu = idSprzetu;
        this.idCzlonka = idCzlonka;
        this.nazwa = nazwa;
        console.log('request-zespol')
    }
    
}