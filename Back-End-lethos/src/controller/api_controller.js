const apiCtrl = {}

apiCtrl.GetPersonaje = (req,res) => {
    req.getConnection((err, conn) => {
       conn.query('select * from Personaje', (err, personajes) => {
           if(err){
               res.json(err);
           }else{
               res.json(personajes);
           }
       });
    });
};

apiCtrl.GetVersion = (req,res) => {
    req.getConnection((err, conn) => {
       conn.query('select * from Versiones', (err, versiones) => {
           if(err){
                res.json(err);
           }else{
                res.json(versiones);
           }
       });
    });
};

apiCtrl.GetPartes = (req,res) => {
    req.getConnection((err, conn) => {
       conn.query('select * from Partes', (err, partes) => {
           if(err){
               res.json(err);
           }else{
                res.json(partes);
           }
       });
    });
};

apiCtrl.GetAccesorio = (req,res) => {
    req.getConnection((err, conn) => {
       conn.query('select * from Accesorios', (err, accesorios) => {
           if(err){
                res.json(err);
           }else{
                res.json(accesorios);
           }
       });
    });
};

apiCtrl.GetEmocion = (req,res) => {
    req.getConnection((err, conn) => {
       conn.query('select * from Emociones', (err, emociones) => {
           if(err){
               res.json(err);
           }else{
                res.json(emociones);
           }
       });
    });
};

module.exports = apiCtrl;