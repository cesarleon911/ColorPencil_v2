const PartesCtrl = {};

PartesCtrl.GetPartes = (req,res) => {
     req.getConnection((err, conn) => {
        conn.query('select * from Partes', (err, partes) => {
            if(err){
                res.json(err);
            }else{
                res.render('partes',{data: partes});
            }
        });
     });
};

PartesCtrl.AddPartes = (req, res) => {
    const datos = req.body;
    req.getConnection((err, conn) => {
        conn.query('insert into Partes set ?',[datos] ,(err, partes) => {
            res.redirect('/Partes');
        });
    });
};

PartesCtrl.DelPartes = (req, res) => {
    const id = req.params.id;    
    req.getConnection((err, conn) => {
        conn.query('delete from Partes where id = ?',[id] ,(err, partes) => {
            res.redirect('/Partes');
        });
    });
};



module.exports = PartesCtrl;