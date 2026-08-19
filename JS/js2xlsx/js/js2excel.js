s2ab = (s) => {
    let buf = new ArrayBuffer(s.length);
    let view = new Uint8Array(buf); 
    for (let i=0; i<s.length; i+=1) view[i] = s.charCodeAt(i) & 0xFF;
    return buf;
}

js2xlsx = () => {

    //creo il nome del file
    const nome = "test";

    //creo un nuovo wb
    let wb = XLSX.utils.book_new();

    //imposto i metadati
    wb.Props = {
        Title: "Test Excel Export",
        Author: "Fabrizio",
        CreatedDate: new Date()
    };

    //creo un nuovo foglio excel
    wb.SheetNames.push("Foglio Excel 1");

    //imposto l'intestazione della tabella
    let ws_data = [['Nome' , 'Cognome']];

    //aggiungo le mie righe desiderate
    ws_data.push(['Fabrizio','Amorelli']);

    //formatto il contenuto per ws
    let ws = XLSX.utils.aoa_to_sheet(ws_data, {raw: false});

    //modifico il font dell'intestazione colonne
    ws["A1"].s = {
        font: {
            bold: true
        }
    };

    ws["B1"].s = {
        font: {
            bold: true
        }
    };

    //applico il filtro all'intestazione
    ws['!autofilter'] = { ref:"A1:B1" };

    //salvo le modifiche nel foglio excel
    wb.Sheets["Foglio Excel 1"] = ws;

    //scrivo
    let wbout = XLSX.write(wb, {bookType:'xlsx',  type: 'binary', cellDates: true});

    //creo e salvo
    saveAs(new Blob([s2ab(wbout)],{type:"application/octet-stream"}), nome+".xlsx");
}