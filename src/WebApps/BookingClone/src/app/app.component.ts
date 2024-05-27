import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  lang: string = 'en'
  curentLang: any;

  title = 'BookingClone';
  currentLang: string = '';
  constructor(public translate: TranslateService, @Inject(DOCUMENT) private document: Document) { }
  //   translate.addLangs(['en', 'ar']);
  //   translate.setDefaultLang('en');
  // }
  // switchLang(lang: string) {
  //   this.translate.use(lang);
  // }
  // changeCurrentLang(lang: string) {
  //   this.translate.use(lang);
  //   localStorage.setItem('currentLang', lang);
  // }

  //Change Lang:






  ngOnInit(): void {
    this.curentLang = localStorage.getItem('curentLang') || 'en';
    this.translate.use(this.curentLang);
    if (this.curentLang == "en") {
      this.document.getElementsByTagName('html')[0].lang = 'en';
      this.document.getElementsByTagName('html')[0].dir = 'ltr';
      this.document.getElementById('Appcontainer')?.classList.remove('is-rtl');

    } else if (this.curentLang == "ar") {
      this.document.getElementsByTagName('html')[0].lang = 'ar';

    }

  }
}
