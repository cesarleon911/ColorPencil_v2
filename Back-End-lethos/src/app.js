const express = require('express');
const path = require('path');
const morgan = require('morgan');
const mysql = require('mysql');
const myConnection = require('express-myconnection');

//inicialiador
const app=express();

const UseRoutes = require('./routes/usuarios_route');
const AccRoutes = require('./routes/accesorios_routes');
const EmoRoutes = require('./routes/emociones_routes');
const ParRoutes = require('./routes/partes_routes');
const PerRoutes = require('./routes/personajes_routes');
const VerRoutes = require('./routes/versiones_routes');
const APIRoutes = require('./routes/api_routes');

const { urlencoded } = require('express');


app.set('port',process.env.PORT || 4000);
app.set('view engine', 'ejs');
app.set('views', path.join(__dirname,'views'));

app.use(morgan('dev'));

app.use(myConnection(mysql, {
    host: 'sql10.freesqldatabase.com',
    user: 'sql10430224',
    password: 'bvIUw8Qyh7',
    port: 3306,
    database: 'sql10430224'
},'single'));
app.use(express.urlencoded({extended:false}));

//rutas
app.use(UseRoutes);
app.use(AccRoutes);
app.use(EmoRoutes);
app.use(ParRoutes);
app.use(PerRoutes);
app.use(VerRoutes);
app.use(APIRoutes);


app.use(express.static(path.join(__dirname,'public')));

app.listen(app.get('port'), () => {
    console.log('server on port', app.get('port'));
});
