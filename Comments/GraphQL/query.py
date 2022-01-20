from datetime import datetime
import strawberry
from Data import data
from typing import List
from typing import Union

@strawberry.type
class CommentDTO:
    id: int
    userId: int
    postId: int
    description: str
    createdOn: datetime

@strawberry.type
class Query:
    @strawberry.field
    def get_comments(self, postId: int) -> List[CommentDTO]:
        return  data.get_comments_byPost(postId)