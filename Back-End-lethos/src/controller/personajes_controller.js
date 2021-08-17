const PersonajeCtrl = {};

PersonajeCtrl.GetPersonaje = (req,res) => {
     req.getConnection((err, conn) => {
        conn.query('select * from Personaje', (err, personajes) => {
            if(err){
                res.json(err);
            }else{
                res.render('personajes',{data: personajes});
            }
        });
     });
};

PersonajeCtrl.AddPersonaje = (req, res) => {
    const datos = req.body;
    req.getConnection((err, conn) => {
        conn.query('insert into Personaje set ?',[datos] ,(err, personajes) => {
            res.redirect('/Personajes');
        });
    });
};

PersonajeCtrl.DelPersonaje = (req, res) => {
    const id = req.params.id;    
    req.getConnection((err, conn) => {
        conn.query('delete from Personaje where id = ?',[id] ,(err, personajes) => {
            res.redirect('/Personajes');
        });
    });
};



module.exports = PersonajeCtrl;