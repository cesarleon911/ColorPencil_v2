const express = require('express');
const router = express.Router();

const emo=require('../controller/emocion_controller');

router.get('/Emociones',emo.GetEmocion);
router.post('/emocionadd',emo.AddEmocion);
router.get('/emociondel/:id',emo.DelEmocion);

module.exports = router;


