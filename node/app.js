var express = require('express')
    , app = express.createServer();
 
app.use(express.bodyParser());
 
app.post('/', function(req, res){
    res.send(req.body);
});
 
app.listen(8080);