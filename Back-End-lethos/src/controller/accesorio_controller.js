const AccesorioCtrl = {};

AccesorioCtrl.GetAccesorio = (req,res) => {
     req.getConnection((err, conn) => {
        conn.query('select * from Accesorios', (err, accesorios) => {
            if(err){
                res.json(err);
            }else{
                res.render('accesorios',{data: accesorios});
            }
        });
     });
};

AccesorioCtrl.AddAccesorio = (req, res) => {
    const datos = req.body;
    req.getConnection((err, conn) => {
        conn.query('insert into Accesorios set ?',[datos] ,(err, accesorios) => {
            res.redirect('/Accesorios');
        });
    });
};

AccesorioCtrl.DelAccesorio = (req, res) => {
    const id = req.params.id;    
    req.getConnection((err, conn) => {
        conn.query('delete from Accesorios where id = ?',[id] ,(err, accesorios) => {
            res.redirect('/Accesorios');
        });
    });
};



module.exports = AccesorioCtrl;