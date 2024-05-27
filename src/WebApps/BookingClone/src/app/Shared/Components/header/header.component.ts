import { DOCUMENT } from '@angular/common';
import { Component, Inject, Renderer2 } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

declare let $: any

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  curentLang: string = ""
  constructor(public translate: TranslateService, private rendrer: Renderer2,
    @Inject(DOCUMENT) private document: Document) {

    this.curentLang = localStorage.getItem('curentLang') || 'en';
    this.translate.use(this.curentLang);

    //Change Lang:
    this.curentLang = localStorage.getItem('curentLang') || 'en';
    this.translate.use(this.curentLang);
    if (this.curentLang == "en") {
      this.document.getElementsByTagName('html')[0].lang = 'en';
      this.document.getElementsByTagName('html')[0].dir = 'ltr';
      this.document.getElementById('Appcontainer')?.classList.remove('is-rtl');


    }
    else if (this.curentLang == "ar") {
      this.document.getElementsByTagName('html')[0].lang = 'ar';
      this.document.getElementsByTagName('html')[0].dir = 'rtl';
      this.document.getElementById('Appcontainer')?.classList.add('is-rtl');
    }

  }


  changeLanguage(lang: string) {
    localStorage.setItem('curentLang', lang)
    this.translate.use(lang);
    if (lang == "en") {
      this.document.getElementsByTagName('html')[0].lang = 'en';
      this.document.getElementsByTagName('html')[0].dir = 'ltr';
      this.document.getElementById('Appcontainer')?.classList.remove('is-rtl');
      $('#lang').modal('hide');

    }
    else if (lang == "ar") {
      this.document.getElementsByTagName('html')[0].lang = 'ar';
      this.document.getElementsByTagName('html')[0].dir = 'rtl';
      this.document.getElementById('Appcontainer')?.classList.add('is-rtl');
      $('#lang').modal('hide');

    }

  }
}
