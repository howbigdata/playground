#!/usr/bin/python
from flask import Flask
import sqlite3
import json
app = Flask(__name__)

@app.route('/solve/<int:processId>', methods=['GET'])
def solve_process(processId):
    conn = sqlite3.connect('file:/db/lca.db?mode=ro', uri=True)
    conn.row_factory = sqlite3.Row
    cursor=conn.execute(f"""
	SELECT methodid, p.elementaryflowid,
       SUM(p.value * m.factor) AS Contrib
	FROM processExchanges p JOIN CharacterisationFactors m
         ON p.elementaryflowid = m.elementaryflowid
	WHERE processid = {processId}
	GROUP BY m.methodid, p.elementaryflowid
	ORDER BY methodid, contrib DESC""");
    return json.dumps([dict(ix) for ix in cursor.fetchall()])
	
if __name__== "__main__":
    app.run(debug=True, host='0.0.0.0')