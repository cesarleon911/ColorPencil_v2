const UsuarioCtrl = {};

UsuarioCtrl.GetUsuario = (req,res) => {
     req.getConnection((err, conn) => {
        conn.query('select * from usuarios', (err, usuarios) => {
            if(err){
                res.json(err);
            }else{
                res.render('usuarios',{data: usuarios});
            }
        });
     });
};

UsuarioCtrl.AddUsuario = (req, res) => {
    const datos = req.body;
    req.getConnection((err, conn) => {
        conn.query('insert into usuarios set ?',[datos] ,(err, usuarios) => {
            res.redirect('/usuario');
        });
    });
};

UsuarioCtrl.DelUsuario = (req, res) => {
    const id = req.params.id;    
    req.getConnection((err, conn) => {
        conn.query('delete from usuarios where id = ?',[id] ,(err, usuarios) => {
            res.redirect('/usuario');
        });
    });
};



module.exports = UsuarioCtrl;