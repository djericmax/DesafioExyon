export class Voo{

    constructor() {
        this.id = 0;
        this.numdoVoo = '';
        this.assento = '';
        this.dataPartida = new Date;
        this.horapartida = '';
        this.valorPassagem = '';
        this.ciaAereaId = 0;
        this.passageiroId = 0;
    }

    id: number;
    numdoVoo: string;
    assento: string;
    dataPartida: Date;
    horapartida: string;
    valorPassagem: string;
    ciaAereaId: number;
    passageiroId: number;
}