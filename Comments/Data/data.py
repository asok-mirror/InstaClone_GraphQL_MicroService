from Data.seed.commentsDataSeed import Seed_comments
from Data.entities.comments import Comment
from typing import List


def getAll_comments() -> List[Comment]:
    return Seed_comments()


def get_comments_byPost(postId) -> List[Comment]:
    comments = Seed_comments()
    return list(filter(lambda c: c.postId == postId, comments))    
