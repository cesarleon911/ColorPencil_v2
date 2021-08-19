const EmocionCtrl = {};

EmocionCtrl.GetEmocion = (req,res) => {
     req.getConnection((err, conn) => {
        conn.query('select * from Emociones', (err, emociones) => {
            if(err){
                res.json(err);
            }else{
                res.render('emociones',{data: emociones});
            }
        });
     });
};

EmocionCtrl.AddEmocion = (req, res) => {
    const datos = req.body;
    req.getConnection((err, conn) => {
        conn.query('insert into Emociones set ?',[datos] ,(err, emociones) => {
            res.redirect('/Emociones');
        });
    });
};

EmocionCtrl.DelEmocion = (req, res) => {
    const id = req.params.id;    
    req.getConnection((err, conn) => {
        conn.query('delete from Emociones where idE = ?',[id] ,(err, emociones) => {
            res.redirect('/Emociones');
        });
    });
};



module.exports = EmocionCtrl;