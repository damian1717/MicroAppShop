import { TranslatePipe } from '../../core/translate/translate.pipe';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { TranslateService } from '../../core/translate/translate.service';

export function setupTranslateFactory(
  service: TranslateService): Function {
  return () => service.use('pl');
}

@NgModule({
  declarations: [TranslatePipe],
  exports: [TranslatePipe],
  providers: [
    TranslateService,
    {
      provide: APP_INITIALIZER,
      useFactory: setupTranslateFactory,
      deps: [TranslateService],
      multi: true
    },
    TranslatePipe
  ]
})
export class TranslateModule { }
