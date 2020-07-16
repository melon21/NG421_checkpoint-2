import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-clothes',
    templateUrl: './clothes.component.html'
})
export class ClothesComponent implements OnInit {
    public clothes: Clothes[];
    public newClothes: Clothes = { type: '', color: '',  fit: '', length: ''};

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    }
    async ngOnInit() {
        this.clothes = await this.http.get<Clothes[]>(this.baseUrl + 'clothes').toPromise();
    }
    async save() {
        await this.http.post<Clothes[]>(this.baseUrl + 'clothes', this.newClothes).toPromise();
        this.newClothes = { type: '', color: '',  fit: '', length: '' };
        this.clothes = await this.http.get<Clothes[]>(this.baseUrl + 'clothes').toPromise();
    }


}

interface Clothes {
    type: string;
    color: string;
    fit: string;
    length: string;
}
