import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';

export const Info = {
  apiUrl : "https://localhost:7071/api", //API do ASP.NET
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
