const express = require('express');
const router = express.Router();

const parte=require('../controller/partes_controller');

router.get('/Partes',parte.GetPartes);
router.post('/parteadd',parte.AddPartes);
router.get('/partedel/:id',parte.DelPartes);


module.exports = router;


