
import { AppConsts } from '@shared/AppConsts';

export class FileDownloadService {

    downloadTempFile(filename: string) {
        const url = AppConsts.remoteServiceBaseUrl + '/File/DownloadTempFile?filename=' + filename;
        location.href = url; //TODO: This causes reloading of same page in Firefox
    }
}
