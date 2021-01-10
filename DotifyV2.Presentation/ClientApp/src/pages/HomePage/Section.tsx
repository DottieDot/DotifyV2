import { Button, Divider, Typography } from '@material-ui/core'
import React, { Fragment, ReactNode, useCallback, useEffect, useState } from 'react'
import { MediaGrid } from '../../components'

interface Props<TItem> {
  batchSize?: number
  title: string
  load: (offset: number, count: number) => Promise<TItem[]>
  renderItem: (item: TItem) => ReactNode
  renderSkeleton: (index: number) => ReactNode
}

export default function <TItem>({ batchSize = 10, title, renderItem, load, renderSkeleton }: Props<TItem>) {
  const [items, setItems] = useState<TItem[] | null>(null)
  const [loading, setLoading] = useState(false)
  const [loadedAll, setLoadedAll] = useState(false)

  const loadItems = useCallback(async () => {
    if (loading || loadedAll)
      return
    setLoading(true)
    const result = await load(items?.length ?? 0, batchSize)
    if (result.length) {
      setItems([
        ...(items ?? []),
        ...result,
      ])
    }
    setLoadedAll(result.length !== batchSize)
    setLoading(false)
  }, [items, setItems, setLoading, loading, loadedAll, setLoadedAll])

  useEffect(() => {
    if (items === null) {
      loadItems()
    }
  }, [loadItems, items, setItems])

  return (
    <Fragment>
      <Typography
        variant="h5"
        component="h2"
        gutterBottom
      >
        {title}
      </Typography>
      <Divider variant="fullWidth" />
      <MediaGrid horizontal>
        {(items === null) ? (
          <Fragment>
            {[...Array(batchSize).keys()].map(renderSkeleton)}
          </Fragment>
        ) : (
          <Fragment>
            {items.map(renderItem)}
            {!loadedAll && (
              <Button
                onClick={loadItems}
                disabled={loading}
                variant="outlined"
              >
                Load More
              </Button>
            )}
          </Fragment>
        )}
      </MediaGrid>
    </Fragment>
  )
}
