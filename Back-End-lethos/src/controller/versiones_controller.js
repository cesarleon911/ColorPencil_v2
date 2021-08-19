const VersionCtrl = {};

VersionCtrl.GetVersion = (req,res) => {
     req.getConnection((err, conn) => {
        conn.query('select * from Versiones', (err, versiones) => {
            if(err){
                res.json(err);
            }else{
                res.render('versiones',{data: versiones});
            }
        });
     });
};

VersionCtrl.AddVersion= (req, res) => {
    const datos = req.body;
    req.getConnection((err, conn) => {
        conn.query('insert into Versiones set ?',[datos] ,(err, versiones) => {
            res.redirect('/Versiones');
        });
    });
};

VersionCtrl.DelVersiones = (req, res) => {
    const id = req.params.id;    
    req.getConnection((err, conn) => {
        conn.query('delete from Versiones where idV = ?',[id] ,(err, versiones) => {
            res.redirect('/Versiones');
        });
    });
};



module.exports = VersionCtrl;