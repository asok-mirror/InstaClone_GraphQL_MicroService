from fastapi import FastAPI
from Data import data
import uvicorn
import strawberry
from strawberry.asgi import GraphQL
import GraphQL.query as query

schema = strawberry.Schema(query=query.Query)

graphql_app = GraphQL(schema)

app = FastAPI()
app.add_route("/graphql", graphql_app)
app.add_websocket_route("/graphql", graphql_app)


@app.get("/healthCheck")
def read_root():
    return {"The Comments API is up and running"}


@app.get("/comments/{post_id}")
def read_item(post_id: int):
    return data.getCommentsByPost(post_id)


if __name__ == "__main__":
    uvicorn.run("main:app", host="127.0.0.1", port=4087, log_level="error")
# uvicorn main:app --reload --port 4087
