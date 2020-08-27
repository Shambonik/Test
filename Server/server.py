from flask import Flask

app = Flask(__name__)

@app.route('/api/User', methods=['POST'])
def index():
    return {
        "id": "1",
        "androidID": "123",
        "nickname": "New player 2",
        "units":
        [
            {
                "id": 1,
                "title": "First unit",
                "modelID": "model_standart_man",
                "gold": 0,
                "xp": 0
            },
            {
                "id": 2,
                "title": "Second unit",
                "modelID": "model_standart_man",
                "gold": 100,
                "xp": 10
            }
        ]
    }

if __name__ == "__main__":
    app.run()